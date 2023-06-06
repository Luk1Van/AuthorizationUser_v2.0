namespace User.DataModel
{
    public class user
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public DateTime created_date { get; set; }
        public int user_group_id { get; set; }
        public int user_state_id { get; set; }
        public user_group _Group { get; set; }
        public user_state _State { get; set; }
    }
}