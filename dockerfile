FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

COPY ./publish ./

ENV ASPNETCORE_URLS=http://0.0.0.0:5154
EXPOSE 5154

ENTRYPOINT ["dotnet", "IT-Quiz-Backend.dll"]
