using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moglan_Vlad_Proiect.Data;


namespace Moglan_Vlad_Proiect.Models
{
    public class DeviceCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Moglan_Vlad_ProiectContext context,
        Device device)
        {
            var allCategories = context.Category;
            var deviceCategories = new HashSet<int>(
            device.DeviceCategories.Select(c => c.DeviceID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = deviceCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateDeviceCategories(Moglan_Vlad_ProiectContext context,
        string[] selectedCategories, Device deviceToUpdate)
        {
            if (selectedCategories == null)
            {
                deviceToUpdate.DeviceCategories = new List<DeviceCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var deviceCategories = new HashSet<int>
            (deviceToUpdate.DeviceCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!deviceCategories.Contains(cat.ID))
                    {
                        deviceToUpdate.DeviceCategories.Add(
                        new DeviceCategory
                        {
                            DeviceID = deviceToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (deviceCategories.Contains(cat.ID))
                    {
                        DeviceCategory courseToRemove
                        = deviceToUpdate
                        .DeviceCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
