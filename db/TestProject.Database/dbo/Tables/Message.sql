CREATE TABLE [dbo].[Message] (
    [MessageId] INT      IDENTITY (1, 1) NOT NULL,
    [PostId]    INT      NOT NULL,
    [UserId]    INT      NOT NULL,
    [Content]   TEXT     NULL,
    [Date]      DATETIME DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([MessageId] ASC),
    CONSTRAINT [FK_Message_Post] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Post] ([PostId]),
    CONSTRAINT [FK_Message_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);


GO

CREATE TRIGGER [dbo].[AfterInsert_Message]
    ON [dbo].[Message]
    FOR INSERT
    AS
    BEGIN
      UPDATE Message
      SET Date = GETDATE()
      FROM inserted
      WHERE Message.MessageId = inserted.MessageId;
    END