CREATE TABLE [dbo].[Post] (
    [PostId]  INT      IDENTITY (1, 1) NOT NULL,
    [UserId]  INT      NOT NULL,
    [Content] TEXT     NOT NULL,
    [Date]    DATETIME DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([PostId] ASC),
    CONSTRAINT [FK_Post_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);


GO

CREATE TRIGGER [dbo].[AfterInsert_Post]
    ON [dbo].[Post]
    FOR INSERT
    AS
    BEGIN
      UPDATE Post
      SET Date = GETDATE()
      FROM inserted
      WHERE Post.PostId = inserted.PostId;
    END