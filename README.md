# QuantMarketing-TechnicalTest

To GET all Accounts

action - GET

/api/account?market=kr

/api/account

To GET account by ID

action - GET

/api/account/1

To DELETE an account

action - DELETE

/api/account/5

To Add new account

action - POST

/api/account/Post?Id=11&Market="IN"&Status="Active"

For adding, I have currenty used FromUri attribute. We can also use HttpMessageRequest to read content

#Things that could be improved or I couldnt acheive due to limited time

Implement Autofac for dependency injection so that objects can be instantiated at runtime. 
For example in AccountController, unitofWork object can be resolved by autofac instead of using constructor to do so.

Could have implemented DBcontext for Account and passed it from unitofwork class to AccountRequest class. 
But as I an using in-memory Account source, I did not implement it. will be essential however with the use of Entity framework.

