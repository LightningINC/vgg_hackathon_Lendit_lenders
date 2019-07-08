using System;

namespace lendit.Model
{
    public class Logger
    {
        public int LoggerId { get; set; }
        public string ErrorType { get; set; }
        public DateTime ErrorDate { get; set; }
        public string ErrorDetails { get; set; }
    }
}