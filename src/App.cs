using System;
using Nancy.Hosting.Self;

namespace Nancy.Simple
{
	class App
	{
		const string StagingPort = "8080";

		static readonly string HOST = Environment.GetEnvironmentVariable ("HOST");
		static readonly string PORT = Environment.GetEnvironmentVariable ("PORT");

		static NancyHost Host;

		enum Env { Staging, Deployment }

		static Env CurrentEnv {
			get {
				return HOST == null ? Env.Staging : Env.Deployment;
			}
		}

		static Uri CurrentAddress {
			get {
				switch (CurrentEnv) {
				case Env.Staging:
					return new Uri ("http://0.0.0.0:8080");
				case Env.Deployment:
					return new Uri (HOST.Substring(0, HOST.Length - 1) + ":" + PORT);
				default:
					throw new Exception ("Unexpected environment");
				}
			}
		}

		static void Main (string[] args)
		{
			Host = new NancyHost (CurrentAddress);
			Host.Start ();
			Console.WriteLine ("Nancy is started and listening on {0}...", CurrentAddress);
			while (Console.ReadLine () != "quit");
			Host.Stop ();
		}
	}
}
