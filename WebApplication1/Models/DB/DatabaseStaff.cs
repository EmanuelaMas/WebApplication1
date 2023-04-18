namespace WebApplication1.Models.DB
{
    public static class DatabaseStaff
    {
        //usare sempre lo using 
        public static List<Staff> GetList()
        {
            using (var ctx = new AcademynetContext())
            {
                return ctx.Staffs.ToList();
            }
                
        }

        public static void AddStaff(Staff s)
        {
            using (var ctx = new AcademynetContext())
            {
                ctx.Staffs.Add(s);
                ctx.SaveChanges();
            }
                
        }

        public static Staff GetPersona(int id)
        {
            using (var ctx = new AcademynetContext())
            {
                return ctx.Staffs.FirstOrDefault(x => x.StaffId == id)!;
            }
        }

        public static void EditPersona(Staff staff)
        {
            using(var ctx = new AcademynetContext())
            {
                var s = ctx.Staffs.FirstOrDefault(x => x.StaffId == staff.StaffId);
                s.FirstName = staff.FirstName;
                s.LastName = staff.LastName;
                s.Email = staff.Email;
                s.StoreId = staff.StoreId;
                ctx.SaveChanges();
            }
            
        }

        public static void RemovePersona(int id)
        {
            using (var ctx = new AcademynetContext())
            {
                var staff = ctx.Staffs.FirstOrDefault(x => x.StaffId == id);
                ctx.Staffs.Remove(staff);
                ctx.SaveChanges();
            }
        }
    }
}
