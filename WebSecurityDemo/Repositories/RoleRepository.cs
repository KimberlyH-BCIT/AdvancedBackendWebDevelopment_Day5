using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WebSecurityDemo.Data;
using WebSecurityDemo.ViewModels;

namespace WebSecurityDemo.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<RoleRepository> _logger;

    public RoleRepository(ApplicationDbContext context, ILogger<RoleRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public List<RoleVM> GetAllRoles()
    {
        return _context.Roles
            .Select(r => new RoleVM
            {
                Id = r.Id,
                RoleName = r.Name ?? ""
            })
            .ToList();
    }

    public RoleVM? GetRole(string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName))
        {
            return null;
        }

        var role = _context.Roles
            .FirstOrDefault(r => r.Name == roleName);

        if (role != null)
        {
            return new RoleVM
            {
                Id = role.Id,
                RoleName = role.Name ?? ""
            };
        }

        return null;
    }

    public bool CreateRole(string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName))
        {
            _logger.LogWarning("Attempt to create role with empty name.");
            return false;
        }

        try
        {
            _context.Roles.Add(new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = roleName,
                NormalizedName = roleName.ToUpperInvariant()
            });

            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating role '{RoleName}'", roleName);
            return false;
        }
    }

    public bool DeleteRole(string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName))
        {
            _logger.LogWarning("Attempt to delete role with empty name.");
            return false;
        }

        try
        {
            var role = _context.Roles
                .FirstOrDefault(r => r.Name == roleName);

            if (role == null)
            {
                return false;   // Role doesn't exist
            }

            _context.Roles.Remove(role);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting role '{RoleName}'", roleName);
            return false;
        }
    }
}

