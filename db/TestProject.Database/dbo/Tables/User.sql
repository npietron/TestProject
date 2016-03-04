CREATE TABLE [dbo].[User] (
    [UserId]  INT          IDENTITY (1, 1) NOT NULL,
    [UserName]    VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

