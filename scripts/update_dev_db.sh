#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" >/dev/null 2>&1 && pwd )"
. $DIR/config.sh

read -ra params <<< "$@"
for (( i=0; i<${#params[@]}; i++))
do
    case "${params[$i]}" in
        --no-refresh|-n)
            no_refresh_db=true
            ;;
        --verbose|-v)
            verbose="-v"
            ;;
        --help|-h|*)
            echo Usage: $(basename $0) [options]
            echo
            echo Options:
            echo "  -n|--no-refresh        Apply dev migration without refresh."
            echo "  -v|--verbose           Show verbose output."
            echo
            exit
            ;;
    esac
done

export DB_ENVIRONMENT=Development

START=$SECONDS

EF_ARG="$verbose"

if [ $no_refresh_db ]; then
    echo [$(($SECONDS-START))s] Step 1: Validate existing database

    if [[ $(docker ps | grep $DOCKER_CONTAINER) ]]; then

        for M in `dotnet ef migrations list -p ./$DB_CONTEXT_PRJ -s ./$FACTORY_PRJ -c $DB_CONTEXT`
        do LM=$M
        done

        if [ "${LM:(-${#DEV_MIGRATION})}" != "$DEV_MIGRATION" ] && [ "${LM:(-${#LAST_MIGRATION})}" != "$LAST_MIGRATION" ]; then
            echo docker container $DOCKER_CONTAINER is not valid
            echo Stopping docker container $DOCKER_CONTAINER
            docker container stop $DOCKER_CONTAINER
            # dotnet ef database drop -p ./$DB_CONTEXT_PRJ -s ./$FACTORY_PRJ -c $DB_CONTEXT
        fi

    fi

else
    echo [$(($SECONDS-START))s] Step 1: Refresh database
    echo Stopping docker container $DOCKER_CONTAINER

    if [[ $(docker ps | grep $DOCKER_CONTAINER) ]]; then
        docker container stop $DOCKER_CONTAINER
    fi
    
fi

echo [$(($SECONDS-START))s] Step 2: Start DB docker container if required

if [[ ! $(docker ps | grep $DOCKER_CONTAINER) ]]; then
    echo Starting docker container
    docker run -it --rm --name=$DOCKER_CONTAINER -p 4321:5432 -e POSTGRES_PASSWORD=postgres -d postgres:11.4
fi

echo [$(($SECONDS-START))s] Step 3: Generate dev migration from current code

for M in `dotnet ef migrations list -p ./$DB_CONTEXT_PRJ -s ./$FACTORY_PRJ -c $DB_CONTEXT`
do LM=$M
done

if [ "${LM:(-3)}" = "$DEV_MIGRATION" ]; then
    dotnet ef database update -p ./$DB_CONTEXT_PRJ -s ./$FACTORY_PRJ -c $DB_CONTEXT $EF_ARG $LAST_MIGRATION
    dotnet ef migrations remove -p ./$DB_CONTEXT_PRJ -s ./$FACTORY_PRJ -c $DB_CONTEXT $EF_ARG
fi

echo Adding new dev migration...
dotnet ef migrations add -p ./$DB_CONTEXT_PRJ -s ./$FACTORY_PRJ -c $DB_CONTEXT $EF_ARG $DEV_MIGRATION

echo [$(($SECONDS-START))s] Step 4: Update database with the new dev migration

dotnet ef database update -p ./$DB_CONTEXT_PRJ -s ./$FACTORY_PRJ -c $DB_CONTEXT $EF_ARG $DEV_MIGRATION

echo [$(($SECONDS-START))s] Completed
