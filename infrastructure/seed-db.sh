#!/usr/bin/env bash

./sqlcmd -S localhost -U sa -P Pass123@ -d master -i ./seed-db.sql
