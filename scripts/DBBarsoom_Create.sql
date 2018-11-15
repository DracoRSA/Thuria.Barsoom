USE [master]
GO

/****** Object:  Database [Barsoom]    Script Date: 11/15/2018 3:07:43 PM ******/
CREATE DATABASE [Barsoom]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Barsoom', FILENAME = N'Barsoom.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Barsoom_log', FILENAME = N'Barsoom_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [Barsoom] SET COMPATIBILITY_LEVEL = 140
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Barsoom].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Barsoom] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Barsoom] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Barsoom] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Barsoom] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Barsoom] SET ARITHABORT OFF 
GO

ALTER DATABASE [Barsoom] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Barsoom] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Barsoom] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Barsoom] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Barsoom] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Barsoom] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Barsoom] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Barsoom] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Barsoom] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Barsoom] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Barsoom] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Barsoom] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Barsoom] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Barsoom] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Barsoom] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Barsoom] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Barsoom] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Barsoom] SET RECOVERY FULL 
GO

ALTER DATABASE [Barsoom] SET  MULTI_USER 
GO

ALTER DATABASE [Barsoom] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Barsoom] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Barsoom] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Barsoom] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Barsoom] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Barsoom] SET QUERY_STORE = OFF
GO

USE [Barsoom]
GO

ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [Barsoom] SET  READ_WRITE 
GO

