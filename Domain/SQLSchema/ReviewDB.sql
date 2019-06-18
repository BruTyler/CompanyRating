CREATE TABLE [dbo].[Reviews] (
    [ReviewID]       INT             IDENTITY (1, 1) NOT NULL,
    [Person]         NVARCHAR (100)  NOT NULL,
    [Company]        NVARCHAR (250)  NOT NULL,
	[Address]        NVARCHAR (250)  NOT NULL,
    [PositiveMoment] NVARCHAR (1050) NOT NULL,
    [NegativeMoment] NVARCHAR (1050) NOT NULL,
    [Comment]        NVARCHAR (1050) NOT NULL,
    [Mark]           INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([ReviewID] ASC)
);