USE [Recruitment]

SET IDENTITY_INSERT [dbo].[workFlowSteps] ON
INSERT INTO [dbo].[workFlowSteps] ([Id], [Description], [IsActive], [OrderNo], [IsMainWorkflow]) VALUES (1, N'Selection', 1, 1, 1)
INSERT INTO [dbo].[workFlowSteps] ([Id], [Description], [IsActive], [OrderNo], [IsMainWorkflow]) VALUES (2, N'Assessment', 1, 2, 1)
INSERT INTO [dbo].[workFlowSteps] ([Id], [Description], [IsActive], [OrderNo], [IsMainWorkflow]) VALUES (3, N'Technical Interview', 1, 3, 1)
INSERT INTO [dbo].[workFlowSteps] ([Id], [Description], [IsActive], [OrderNo], [IsMainWorkflow]) VALUES (4, N'HR Interview', 1, 4, 1)
INSERT INTO [dbo].[workFlowSteps] ([Id], [Description], [IsActive], [OrderNo], [IsMainWorkflow]) VALUES (7, N'Final Interview', 1, 5, 1)
SET IDENTITY_INSERT [dbo].[workFlowSteps] OFF


GO

SET IDENTITY_INSERT [dbo].[applicantProfiles] ON
INSERT INTO [dbo].[applicantProfiles] ([ApplicantNo], [Id], [IsSuccess], [WorkFlowId]) VALUES (N'883240111V', 1, 1, 1)
INSERT INTO [dbo].[applicantProfiles] ([ApplicantNo], [Id], [IsSuccess], [WorkFlowId]) VALUES (N'883240111V', 2, 1, 2)
INSERT INTO [dbo].[applicantProfiles] ([ApplicantNo], [Id], [IsSuccess], [WorkFlowId]) VALUES (N'883240111V', 3, 1, 3)
INSERT INTO [dbo].[applicantProfiles] ([ApplicantNo], [Id], [IsSuccess], [WorkFlowId]) VALUES (N'883240111V', 4, 0, 4)
SET IDENTITY_INSERT [dbo].[applicantProfiles] OFF
