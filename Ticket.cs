namespace WillHuck
{
    class Ticket
    {
                        //         Console.WriteLine("Ticket ID:");
                        // input += Console.ReadLine();
                        // Console.WriteLine("Summary:");
                        // input += ',' + Console.ReadLine();
                        // Console.WriteLine("Status:");
                        // input += ',' + Console.ReadLine();
                        // Console.WriteLine("Priority:");
                        // input += ',' + Console.ReadLine();
                        // Console.WriteLine("Submitter:");
                        // input += ',' + Console.ReadLine();
                        // Console.WriteLine("Assigned:");
                        // input += ',' + Console.ReadLine();
                        // Console.WriteLine("Watching:");
                        // input += ',' + Console.ReadLine();
        public int Id;
        public string Summary;
        public string Status;
        public string Priority;
        public string Submitter;
        public string Assigned;
        public string Watching;

        public Ticket(string id, string summ, string status, string pri, string subm, string assign, string watching) {
            this.Id = int.Parse(id);
            this.Summary = summ;
            this.Status = status;
            this.Priority = pri;
            this.Submitter = subm;
            this.Assigned = assign;
            this.Watching = watching;
        }
        public override string ToString()
        {
            return $"{this.Id, 12}{this.Summary,30}{this.Status,12}{this.Priority,12}{this.Submitter,12}{this.Assigned,12}{this.Watching,45}";
        }
        public string ToFileString() 
        {
            return this.Id.ToString()+','+this.Summary+','+this.Status+','+this.Priority+','+this.Submitter+','+this.Assigned+','+this.Watching;
        }
    }
}