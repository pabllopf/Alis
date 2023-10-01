#!/bin/bash

echo "Do you want to restart permissions of solution? (y/n)"
select yn in "Yes" "No"; do
    case $yn in
        Yes ) 
          
          cd ../../../
          
          sudo chmod 777 -R .
          
          sudo dotnet dev-certs https --trust
          
          cd ./scripts/linux/ || exit
          
          break;;
        No ) 
          echo "Goodbye!"
          exit;;
    esac
done

