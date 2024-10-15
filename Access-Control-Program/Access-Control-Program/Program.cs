using System;
using System.Data;

public enum Role
{
    Admin,
    User,
    Moderator
}

class Program
{
    static void Main(string[] args)
    {
        AdminAccessController adminController = new AdminAccessController();

        adminController.AddUser("Alice", Role.Admin);
        adminController.AddUser("Bob", Role.User);
        adminController.AddUser("Charlie", Role.Moderator);

        adminController.AddUser("Alice", Role.Moderator);

        adminController.ListUsers();

        adminController.GetUserRole("Dave"); 

        Role? aliceRole = adminController.GetUserRole("Alice");
        bool aliceHasAccess = aliceRole.HasValue && AccessController.CheckAccess(aliceRole.Value);
        adminController.LogAccess("Alice", aliceHasAccess);

        Role? bobRole = adminController.GetUserRole("Bob");
        bool bobHasAccess = bobRole.HasValue && AccessController.CheckAccess(bobRole.Value);
        adminController.LogAccess("Bob", bobHasAccess);

        adminController.TrackAccessAttempt("Bob", bobHasAccess);
        Console.WriteLine($"Bob has {adminController.GetFailedAttempts("Bob")} failed access attempts.");

        adminController.GrantPrivileges("Bob", Role.Moderator);

        adminController.RevokePrivileges("Dave"); 


        adminController.RevokePrivileges("Charlie");

        adminController.ViewAccessLogs();

        adminController.RemoveUser("Alice");
    }
}
