# eVMS
Microservice Architecture with .net Core

# Step 1
dotnet restore
# Step 2
    1. Run the CMS API
    2. Generate the token localhost:port/cmsapi/token
    3. Get the access_token
    4. Can call the other endpoints by adding Authorization header with Bearer token

# Step 3
    1. Run the eStore API
    2. Generate the token localhost:port/estoreapi/token
    3. Get the access_token
    4. Can call the other endpoints by adding Authorization header with Bearer token
# Step 4
    1. Run the eVMS.Web project
    2. Check the eVouchers
    3. Can do delete (Inactive)
    4. Create eVoucher (not finished)
    5. Update eVoucher (not finished)
    6. Purhcase Histories (not finished)
