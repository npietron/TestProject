﻿namespace TestProject.Services.Contracts.Message
{
    public class MessageDto
    {
        public int MessageId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}
