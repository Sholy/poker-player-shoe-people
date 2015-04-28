task :default => :stage

desc "Build app"
task :build do
	sh "xbuild *.sln"
end

desc "Deploy to Heroku"
task :deploy => :build do
	sh "git push heroku master"
end

desc "Stage locally"
task :stage => :build do
	sh "foreman start local"
end

desc "Creates a Heroku app"
task :init do
	sh "heroku create --stack cedar-14 --buildpack http://github.com/BenHall/heroku-buildpack-mono"
	if `git remote show -n heroku` =~ /git@heroku.com:(.+)\.git/
		host = $1
		sh "heroku config:set HOST=#{host}.herokuapp.com"
		sh "heroku config:set PORT=8080"
		sh "echo \"HOST=#{host}\" >> .env"
		sh "echo \"PORT=8080\" >> .env"
	else
		puts "Could not detect app hostname. Please configure your HOST environment variable manually"
	end
	Rake::Task[:deploy].invoke
	sh "heroku open"
end
