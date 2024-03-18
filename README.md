# Llama2Communicator

A web app that communicates with Llama2 via Ollama. At this time it is a super basic implementation that is a P.O.C at this time.

To set up this project, you have a few options, but here are the two options I have tested to get Ollama running:

1. https://ollama.com/download
2. Recommended: https://hub.docker.com/r/ollama/ollama

Option 2 is recommended because it allows you to set it up in Docker and expose it on your local IP. Then, you can use Docker to expose the Llama2Communicator on your local IP. This way, anyone you trust on your network can run prompts without needing curl commands.

After choosing your installation option and following the installation instructions for the options mentioned above...

This project depends on llama2-uncensored however, you can change the dependency below during the "Model Settings" section.

## DO NOT MISS THESE STEPS - You don't have to use 
If you chose option 1, run this command:
```
ollama run llama2-uncensored
```

If you chose option 2, run this command:
```
docker exec -it ollama ollama run llama2-uncensored
```

If you don't plan to run llama2-uncensored you can update the above commands for your specific model.

After running the command, it should take you to the shell in the container where you can communicate with the model. Type /bye and hit enter.

After completing these steps and cloning down this project, you can update the **appsettings.json** configuration. If you are using the Docker installation, you can update the base URL below to be your local IP. The port number is usually 11434, but you may need to investigate if that port was already occupied prior to installation. Leave the extension as is.

```
"ModelSettings": {
    "BaseUrl": "insert url here.... format is http://localhost",
    "Port": "insert port number here",
    "Extension": "api",
    "Model": "llama2-uncensored"
}
```

If you don't want to use llama2-uncensored you can update "Model" with the model you are using. This project has only been tested in the llama2 ecosystem.

Once you have completed that, you have another two options: 1) Run with your IDE like Rider or Visual Studio, 2) Use Docker to deploy.

If you choose option 2, cd into the root directory of this project and run the following commands:
```
docker build -t llamacommunicator .
```

```
docker run -d -p 8080:8080 --name llamacommunicator llamacommunicator
```

Now, you can either access the UI via **localhost:8080** or **-your.local.ip.here-:8080** and can share that with people you trust on your network!
