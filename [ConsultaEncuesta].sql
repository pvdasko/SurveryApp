USE [Cuestionario]
GO
/****** Object:  StoredProcedure [dbo].[ConsultaEncuesta]    Script Date: 04/06/2017 09:55:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,NRL>
-- Create date: <Create Date,28/05/2017>
-- Description:	<Description,Return query survey>
-- EXEC [dbo].[ConsultaEncuesta] 1,'BK', 'H'
-- =============================================
ALTER PROCEDURE [dbo].[ConsultaEncuesta]
	-- Add the parameters for the stored procedure here
	@Corporativo int,
	@Hotel nvarchar(50),
	@Tipo nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select p.Corporativo, 
	p.Hotel, 
	p.[Tipo Cuestionario],    
	p.[No Pregunta] , 
	P.[Tipo Pregunta] , 
	P.Pregunta, 
	P.[Pregunta Ingles] , 
	P.[Calificacion Maxima], 
	R.[No Respuesta],
	R.Respuesta , 
	R.[Respuesta Ingles] , 
	R.[Respuesta Abierta] , 
	(select max([No Respuesta]) from [dbo].[C_Respuestas Cuestionario] where [No Pregunta] = P.[No Pregunta] ) as Maximo
	from [dbo].[C_Preguntas Cuestionario] P
	inner join  [dbo].[C_Respuestas Cuestionario] R on P.[Tipo Cuestionario]= R.[Tipo Cuestionario] and P.[No Pregunta]= R.[No Pregunta]
	where p.Corporativo =@Corporativo 
	and p.Hotel = @Hotel
	and p.[Tipo Cuestionario] = @Tipo
	order by p.Corporativo, p.Hotel, p.[Tipo Cuestionario], p.[No Pregunta] ,  r.[No Respuesta] 
	END
