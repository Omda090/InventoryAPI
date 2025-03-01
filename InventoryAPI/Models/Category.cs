﻿namespace InventoryAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        // Navigation Property: One category can have multiple inventory items
        public ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();

    }
}
