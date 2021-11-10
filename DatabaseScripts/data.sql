SET IDENTITY_INSERT [dbo].[Weather] ON
INSERT INTO [dbo].[Weather] ([Id], [Country], [Region], [Temperature], [WindSpeed], [Feel]) VALUES (1, N'New Zealand', N'Auckland', 10, 30, N'Cold')
INSERT INTO [dbo].[Weather] ([Id], [Country], [Region], [Temperature], [WindSpeed], [Feel]) VALUES (2, N'India', N'Mumbai', 33, 40, N'Humid')
INSERT INTO [dbo].[Weather] ([Id], [Country], [Region], [Temperature], [WindSpeed], [Feel]) VALUES (3, N'US', N'Zew York', 4, 29, N'Cold')
INSERT INTO [dbo].[Weather] ([Id], [Country], [Region], [Temperature], [WindSpeed], [Feel]) VALUES (5, N'UK', N'London', 16, 37, N'Extremely Cold')
INSERT INTO [dbo].[Weather] ([Id], [Country], [Region], [Temperature], [WindSpeed], [Feel]) VALUES (6, N'Canada', N'Ontario', 10, 20, N'Very Cold')
SET IDENTITY_INSERT [dbo].[Weather] OFF
