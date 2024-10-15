Access Control System in C#
This project implements a role-based access control system in C# using abstract classes, inheritance, and role management. The system provides functionality for adding, removing, and managing users with different roles (Admin, Moderator, User). It also includes access logging, privilege management, and basic error handling using conditional statements.

Key Features:
Role-Based Access Control: Users are assigned roles (Admin, Moderator, or User), and access is granted or denied based on these roles.
Abstract and Inherited Classes: The base AccessController class defines shared functionality for handling users and tracking access attempts. The AdminAccessController class extends it to provide additional functionality, such as privilege management and logging access attempts.
Conditional Exception Handling: Exceptions are managed using if-else statements rather than multiple try-catch blocks to ensure lightweight and efficient error handling.
Access Logging: The system logs successful and failed access attempts, which can be reviewed later.
Privilege Management: Admins can grant or revoke privileges for users, adjusting their roles dynamically.
Failed Attempts Tracking: Tracks failed access attempts for users and allows viewing their failed access history.
Project Structure:
Role.cs: Defines the Role enum (Admin, Moderator, User).
AccessController.cs: The base abstract class for handling user management and access attempts.
AdminAccessController.cs: Extends AccessController to add admin-level functionalities such as logging and privilege management.
Program.cs: The main entry point demonstrating the usage of the access control system.
