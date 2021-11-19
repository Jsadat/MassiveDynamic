# Massive Dynamic Protal-Based management System
Login
Massive Dynamic management system needs to be protected. Anonymous users are not
allowed to access the system without signing in first. Accessing pages directly through URL should redirect you to the login page and after successfully signing in back to the requested page.
Users
Massive Dynamic needs to have a user management section where they can manage the
users that have access to the system. When creating the user, you’ll need to have at least the
following fields:
 	- Name
- Username
- Password
- Email
- Role (Administrator, secretary, client)
	Administrators have access to everything and are the only role to be allowed todelete
	Secretary has only access to clients. They must be able to manage the        clients.
	Client is the role that only has access to their own data. They can see their own information that has been filled in (for control). They are however not allowed to view the uploaded documents.
Clients
Massive Dynamic must have an option to add their clients. A client is usually a company with one or more contact persons. I must be able to manage my clients and manage the documents we have requested from them and assign to the specific client.
Clients must have a unique human-readable identifier on which we can find the client in the system. The Client ID should be 6 characters long and must contain numeric and alpha characters.
