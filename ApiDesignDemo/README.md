# ApiDesignDemo: Modern REST API Design Demo

This project demonstrates best practices and common pitfalls in designing RESTful APIs using a social media example (Users, Posts, Likes, Friends).

## Project Structure

- **Controllers/**: Handle HTTP requests, map to services, and return responses.
- **Services/**: Contain business logic, orchestrate repositories.
- **Repositories/**: Data access layer, abstract data storage.
- **DTOs/**: Data Transfer Objects for API input/output.
- **Models/**: Domain entities.

## RESTful Best Practices

### 1. Resource-Oriented URLs
- Good: `/api/users/123` (Get user by ID)
- Good: `/api/posts/456/likes` (Get likes for a post)
- Good: `/api/users/123/friends` (Get friends for a user)
- Good: `/api/users/123/posts` (Get posts for a user)
- Bad: `/api/user/{post}/likes` (What is `{post}` doing under `user`? This is confusing!)

### 2. Use HTTP Methods Properly
- `GET /api/posts` — List posts
- `POST /api/posts` — Create post
- `PUT /api/posts/1` — Update post
- `DELETE /api/posts/1` — Delete post

### 3. Consistent Naming
- Use plural nouns for collections: `/api/users`, `/api/posts`
- Use nested resources for relationships: `/api/posts/{postId}/likes`

### 4. Avoid Deep Nesting
- Good: `/api/posts/{postId}/likes`
- Bad: `/api/users/{userId}/posts/{postId}/likes` (Too deep, unnecessary)

### 5. Clear Resource Hierarchy
- Only nest when there is a clear parent-child relationship.
- Likes belong to posts, not users: `/api/posts/{postId}/likes` is correct.

### 6. Use Proper Status Codes
- `200 OK`, `201 Created`, `204 No Content`, `400 Bad Request`, `404 Not Found`, etc.

### 7. Separation of Concerns
- Controllers: HTTP logic only
- Services: Business logic
- Repositories: Data access

### 8. DRY & SOLID Principles
- Reuse code via services and repositories.
- Use interfaces for abstraction.
- Single Responsibility: Each class has one job.

## Common Pitfalls (Anti-Patterns)

- **Confusing URLs**: `/api/user/{post}/likes` — `{post}` is not a user, this is misleading.
- **Verb-based URLs**: `/api/getAllUsers` — Use HTTP methods, not verbs in URLs.
- **Deep nesting**: `/api/users/{userId}/posts/{postId}/likes/{likeId}` — Avoid unless necessary.
- **Mixing concerns**: Business logic in controllers or data access in services.

## Example Endpoints

- `GET /api/users` — List users
- `GET /api/users/1` — Get user by ID
- `POST /api/users` — Create user
- `GET /api/posts` — List posts
- `GET /api/posts/1` — Get post by ID
- `GET /api/posts/1/likes` — Get likes for a post
- `POST /api/posts/1/likes` — Like a post
- `GET /api/users/1/friends` — Get friends for a user

## See Also
- [RESTful API Design - Best Practices](https://restfulapi.net/)
- [Microsoft REST API Guidelines](https://github.com/microsoft/api-guidelines)

---

This demo is designed to help new developers understand how to compose clean, maintainable, and truly RESTful APIs.
