# HolidayMaker Group 1

This is Ukubhuka, a hotel booking site created during spring 2021 at Newton YH in Malmö.

This project uses the following technologies:

- Vue 3 Vite
- ASP.Net Core Web Api
- MS SQL
- Stripe Payment

## Prerequisites
1. .Net Core SDK
2. Node.JS Stable
3. MS SQL

## Usage:
1. Clone the repo
2. Then run the following:

```bash
npm install # in frontend directory
npm run dev # in frontend directory
```
3. Create the database with the provided Database_SQL_Script.sql script in the Docs folder
4. Change the connection string in HolidayMakerContext.cs to your own string
5. Make sure the backend server is on the port 44356. Alternatively you can find and replace this port where necessary
6. Run the asp net backend server with your preferred choice (either in vs studio or via terminal)
7. Default frontend can be found at localhost:3000
