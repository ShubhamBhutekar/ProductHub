# ProductHub

ProductHub is a simple project built using **ASP.NET MVC** with **Entity Framework (Code First Approach)**.

## ASP.NET MVC Machine Test

**Approach:** Entity Framework, Code First
**Note:** Scaffolding must not be used.

### Requirements

1. **Category Master** — with full CRUD (Create, Read, Update, Delete) operations.
2. **Product Master** — with full CRUD operations. Each product must belong to a category.
3. **Product List View** — should display the following columns:
   - Product Id
   - Product Name
   - Category Id
   - Category Name
4. **Server-Side Pagination** — the product list must implement pagination on the server side, meaning records should be fetched from the database according to the selected page size, rather than loading all records and paginating on the client.

   *Example:* If the page size is 10 and the user navigates to page 9, only records 90–100 should be queried and retrieved from the database.
1) UER INTERFACE
   
![Screenshot (912)](https://github.com/user-attachments/assets/e34ad3f7-b561-41e8-941c-66a23817f7ac)

2)CODE ENVIRONMENT

![Screenshot (913)](https://github.com/user-attachments/assets/edb9dfab-fabe-43d3-aa61-055196d5e406)
