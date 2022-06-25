job('Application in .Net Core') {
  description('Application made in .Net Core 5')
  scm {
    git('https://github.com/AndyVillegas/kruger.git', 'test-jenkins') { node -> 
      node / gitConfigName('AndyVillegas')
      node / gitConfigEmail('andyvillegas440@gmail.com')
    }
  }
  triggers {
    scm('H/7 * * * *')
  }
  steps {
    dotnetBuild {
      project('src/Kruger.Application/Kruger.Application.csproj')
    }
  }
}
