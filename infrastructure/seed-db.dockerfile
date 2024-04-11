FROM mcr.microsoft.com/mssql-tools

ARG BUILD_DATE

COPY ./seed-db.sql ./seed-db.sql
