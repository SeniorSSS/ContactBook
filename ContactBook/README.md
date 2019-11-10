
**Task** - create Web API which stores and allow to manage contacts in database. 
**Term**s:
- [x] Entinty Framework
- [ ] Vue.js

**Tests**:
- [x] Unity tests for data validation
- [ ] Test for endpoint using typescript in Visual Code

**Data**:
**Contact**:
- [x] Name (validation, required)
- [x] Phone Number (validation, possibly multiple (1:n))
- [x] Email (validation, possibly multiple (1:n))
- [x] Company
- [x] Note
- [x] Address (validation, possibly multiple (1:n))

**Functionality**:
- [x] Add 
- [x] Update
- [x] Delete
- [x] Search by Name, Company, Phone and Email
- [ ] Bonus - Map with pin on address
- [ ] Bonus - User login and personal contacts for user.

**Presentation**:
- [x] Github Pull Request
- [ ] Readme with step by step manual
- [ ] Bonus for automatic setup

I decided to create separate endpoints for each table so data which frontend sends and receives is minimal. Like, if client decide to add email, it adds it at the moment when button "save email" is pressed without waiting for all contact changes saving or collecting all contact data. Same with update and delete for any lookup tables. Main contact data is managed in one heap. And frontend uses contact id to collect all data from lookup tables.

Basically, each table (except Contact) have such endpoint 
- **read** - (GET) api/{table}/{id} where id is contact Id and return is list of record Id and record data.
- **add**- (POST) api/{table} with data containing contact Id and data to add
- **update** - (PUT)api/{table} with data containing record Id and data to update
- **delete** -(DELETE) api/{table}/{id} where id is record to delete Id

For example to delete email with email Id = 5 request must be HTTPDELETE **api/emails/5**

Specific endpoints:
**api/get/contactsNames** - returns only contact Id and Name for listing purpose.

Responce errors status can be:
400 (Bad request) when data doesn't pass validation. 
