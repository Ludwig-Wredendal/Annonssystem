CREATE TABLE [dbo].[tbl_ads] (
    [ad_id] INT           IDENTITY (1, 1) NOT NULL,
    [ad_varupris]         INT           NULL,
    [ad_innehall]         NVARCHAR (50) NULL,
    [ad_rubrik]           NVARCHAR (50) NULL,
    [ad_annonspris]       INT           NULL,
    
    CONSTRAINT [PK_tbl_ads] PRIMARY KEY CLUSTERED ([ad_id] ASC)
);

CREATE TABLE [dbo].[tbl_annonsorer] (
    [an_id] INT           IDENTITY (1, 1) NOT NULL,
    [an_prenumerant]      INT           NULL,
    [an_ads]              INT NULL,
    [an_foretag]          INT NULL,
    [an_namn]             NVARCHAR (50) NULL,
    [an_organisationsnummer]             INT NULL,
    [an_telefonnummer]             INT NULL,
    [an_utdelningsadress]             NVARCHAR (50) NULL,
    [an_postnummer]             INT NULL,
    [an_ort]             NVARCHAR (50) NULL,
    
    CONSTRAINT [PK_tbl_annonsorer] PRIMARY KEY CLUSTERED ([an_id] ASC),
    CONSTRAINT [PK_tbl_annonsorer_tbl_ads] FOREIGN KEY ([an_ads]) REFERENCES [dbo].[tbl_ads] ([ad_id]) ON DELETE CASCADE

);
