# eVMS
Microservice Architecture with .net Core

# Database Restore
    1. Create database "eVoucher"
    2. Run the script file "sql_evoucher"

# Step 1
dotnet restore
# Step 2
    1. Change the db connection string in appsettings.json
    2. Run the CMS API
    3. Generate the token localhost:port/cmsapi/token
    4. Get the access_token
    5. Can call the other endpoints by adding Authorization header with Bearer token

# Step 3
    1. Change the db connection string in appsettings.json
    2. Run the eStore API
    3. Generate the token localhost:port/estoreapi/token
    4. Get the access_token
    5. Can call the other endpoints by adding Authorization header with Bearer token
# Step 4
    1. Run the eVMS.Web project
    2. Check the eVouchers
    3. Can do delete (Inactive)
    4. Create eVoucher (not finished)
    5. Update eVoucher (not finished)
    6. Purhcase Histories (not finished)
