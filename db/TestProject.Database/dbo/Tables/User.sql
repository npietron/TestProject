CREATE TABLE [dbo].[User] (
    [UserId]  INT          IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (20) NULL,
    [Surname] VARCHAR (20) NULL,
    [Nick]    VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

