# Requirements
1. The API developed in the first week must be used. ✔️

2. The API must be a RESTful API ✔️

3. The project must adhere to SOLID principles. ✔️

4. Fake services must be developed, Dependency Injection must be used. ✔️

Managers
```bash
Api/Services/Concrete/CategoryManager.cs
Api/Services/Concrete/ProductManager.cs
```

Services 
```bash
Api/Services/Abstract/IProductService.cs
Api/Services/Abstract/ICategoryService.cs
```

Dependency Injection has been applied in Controllers.
```bash
Api/Controllers/ProductsController.cs
Api/Controllers/CategoriesController.cs
```

Example:
```cs
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
// codes..
```

5. Developed an extension to be used in your API. ✔️

```bash
Api/Extensions/ServiceCollectionExtensions.cs
```

6. Swagger must be implemented in the project. ✔️

<br>

8. A global logging middleware must be implemented. (at a very basic level, like logging when entering an action) ✔️

```bash
Api/Middlewares/LoggingMiddleware.cs
```

## Bonus

1. Implement a fake user login system and control it with a custom attribute.  ✔️
  * Session was used for authentication.
  * An action filter attribute was implemented.

Action Filter Attribute
```bash
Api/ActionFilters/CustomAuthorize.cs
```

``UsersController`` provides authentication.
* To test the login, ``username: "admin"`` and ``password: "123"`` could be used as the payload. <br> URI: ``/api/Users/login``
  
<br>

* Another endpoint with URI: ``/api/Users/test`` were utilized for testing purposes. When a ``GET`` request is sent, if the user is already logged in, the method returns the username; otherwise, a 401 Unauthorized status is returned by ``CustomAuthorized`` action filter attribute.

```bash
Api/Controllers/UsersController.cs
```

2. Create a global exception middleware.  ✔️
```bash
Api/Middlewares/ExceptionMiddleware.cs
```
