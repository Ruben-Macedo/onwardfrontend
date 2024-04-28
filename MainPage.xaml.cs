﻿using System.Net;

namespace Onward;

public partial class MainPage : ContentPage
{
	private readonly ServerSocket serverSocket;

	public MainPage()
	{
		serverSocket = new();
		InitializeComponent();
	}

	private async void LoginAndAuthenticate(object sender, EventArgs e)
	{
		string response = await serverSocket.Login(Username.Text, Password.Text);
		if (response.Equals(HttpStatusCode.OK.ToString()) && Application.Current != null)
		{
            Application.Current.MainPage = new AppShell();
		}
		else
		{
			await DisplayAlert("Could not authenticate", "Invalid Credentials", "Cancel");
		}
	}
}

