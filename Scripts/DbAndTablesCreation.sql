USE [master]
GO

CREATE DATABASE [Recruitment]

GO


USE [Recruitment]
GO

CREATE TABLE [dbo].[workFlowSteps] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Description]    NVARCHAR (MAX) NULL,
    [IsActive]       BIT            NOT NULL,
    [OrderNo]        INT            NOT NULL,
    [IsMainWorkflow] BIT            NOT NULL
);



USE [Recruitment]
GO

CREATE TABLE [dbo].[applicantProfiles] (
    [ApplicantNo] NVARCHAR (MAX) NULL,
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [IsSuccess]   BIT            NOT NULL,
    [WorkFlowId]  INT            NOT NULL
);


