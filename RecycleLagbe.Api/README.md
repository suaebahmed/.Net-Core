# Data Model vs DTO

Data Models (e.g., Database Models):
Purpose: Define the structure and relationships of data as it's stored in a database or other persistent storage.

### Key Differences Summarized:
- Focus:
DTOs focus on data transfer, while Models (especially Domain Models) focus on representing business concepts and behavior.

- Behavior:
DTOs are typically data-only, whereas Domain Models contain business logic. View Models may contain presentation-specific logic.

- Scope:
DTOs are used for inter-layer communication, Domain Models represent the core business, and View Models are tailored for UI presentation.


# Design Pattern
- CQRS | (Commands, Query, Responsibility and Segregation)
	- Separate Commands and Queries
	- 
- Repository 
	- Repository Design Pattern separates the data access logic and maps it to the entities in the business logic
	- 
- Factory 

# Controller Action Return Types

- Primitive or Complex Types: Use for simple, straightforward responses where detailed control over the response is not needed.
- IActionResult: We need to use IActionResult when we need to return different types of responses (e.g., success, error, not found) from a single action method.
- ActionResult<T>: We need to use ActionResult<T> to return a specific type of data along with the flexibility to return different HTTP status codes. This provides clear API documentation.
- Specific Result Types: We need to use specific result types when we want to be explicit about the kind of response returned, allowing direct control over the response type and status code.
	- 1. OkResult and OkObjectResult
	- 2. NotFoundResult and NotFoundObjectResult
	- 3. BadRequestResult and BadRequestObjectResult
- Task<IActionResult> or Task<ActionResult<T>>: These two return types are used for asynchronous action methods that perform I/O-bound operations like database calls, file I/O, or external service calls.


# Data binding

Query Strings: Parameters appended to the URL.
Route Data: Parameters defined in the URL path.
Form Data: Data submitted via HTML forms (typically for POST requests).
Request Body: Payload data, often in JSON or XML format (commonly for POST, PUT, or PATCH requests).
Headers: Custom data sent within HTTP headers.

## Why Is Model Binding Important is ASP.NET core Web API

- 1. Simplified Data Handling
- 2. Maintainability & Supports Multiple Data Source
- 3. Validation Integration: easily integrate validation logic, 

Use data annotations to define validation rules:
	


