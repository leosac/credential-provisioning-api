pipeline {
    agent any
    environment {
        DOTNET_SYSTEM_GLOBALIZATION_INVARIANT = 1
    }
    tools {
        dotnetsdk 'dotnet8'
    }
	stages {
        stage('Pre-Build') {
            steps {
                dotnetRestore()
            }
        }
	    stage('Build') {
            steps {
                dotnetBuild()
            }
        }
        stage('Sonar') {
            environment {
                scannerHome = tool 'SonarScanner for MSBuild'
            }
            steps {
                withSonarQubeEnv('SonarQube Community') {
                    sh "dotnet ${scannerHome}/SonarScanner.MSBuild.dll begin /k:'leosac_credential-provisioning-api_01d82b4b-1d29-4cd3-a08a-1b5c31be0e9c'"
                    dotnetBuild()
                    sh "dotnet ${scannerHome}/SonarScanner.MSBuild.dll end"
                }
                timeout(time: 1, unit: 'HOURS') {
                    waitForQualityGate(abortPipeline: true)
                }
            }
            when {
                anyOf {
                    branch 'main'
                    buildingTag()
                    changeRequest()
                }
            }
        }
    }
}