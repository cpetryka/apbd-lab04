namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            null,
            "Kowalski",
            "kowalski@gmail.com",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        // Assert.Equal(false, result);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@gmailcom",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThan21YearsOld()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@gmail.com",
            DateTime.Parse("2010-01-01"),
            1
        );

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
          // Arrange
          var userService = new UserService();

          // Act
          var result = userService.AddUser(
              "Jan",
              "Malewski",
              "malewski@gmail.com",
              DateTime.Parse("2000-01-01"),
              2
          );

          // Assert
          Assert.True(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "John",
            "Smith",
            "smith@gmail.com",
            DateTime.Parse("2000-01-01"),
            3
        );

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan",
            "Kwiatkowski",
            "kwiatkowski@gmail.com",
            DateTime.Parse("2000-01-01"),
            5
        );

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@gmail.com",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ThrowsExceptionWhenUserDoesNotExist()
    {
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Jan",
            "Wikariak",
            "wikariak@gmail.com",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void AddUser_ThrowsArgumentExceptionWhenClientDoesNotExist()
    {

        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@gmail.com",
            DateTime.Parse("2000-01-01"),
            100
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void AddUser_ThrowsExceptionWhenNoCreditLimitExistsForUser()
    {

        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Jan",
            "Niekrasz",
            "niekrasz@gmail.com",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
    }
}