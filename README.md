# Llama2Communicator
A web app that talks with Llama2 via ollama

To set this project up you have a few options but these are the 2 options I have tested to get Ollama going.

1. https://ollama.com/download
2. Recommended: https://hub.docker.com/r/ollama/ollama

Option 2 is recommended because you set it up in Docker and can expose it on your local IP. And then you can use Docker to expose the Llama2Communicator on your local IP. Anyone you trust on your network can run prompts w/ out curl commands.

After you have chosen your installation and followed the install instructions for the above options...

This project depends upon llama2-uncensored.

## DO NOT MISS THESE STEPS
_______________________________________________________________________________________
If you chose option 1 run this command
```
ollama run llama2-uncensored
```
_______________________________________________________________________________________
If you chose option 2 run this command
```
docker exec -it ollama ollama run llama2-uncensored
```

After you have run that it should take you to the shell in the container where you can communicate with the model. Type /bye and hit enter.
_______________________________________________________________________________________

After this is done, and you have cloned down this project you can update the appsettings.json configuration...
If you are using Docker installation you can update the base url below to be your local IP. The port number is usually 11434 but you may need to do some digging if that port number was already occupied prior to install.
Leave extension as is.
```
"Llama2Settings": {
    "BaseUrl": "insert url here.... format is http://localhost",
    "Port": "insert port number here",
    "Extension": "api"
  }
```

Once you have completed that you have another 2 options 1) Run with your IDE like Rider or Visual Studio, 2) Use docker to deploy.

If you chose 2, cd into the root directory of this project and run the below commands.
```
docker build -t llamacommunicator .
```

```
docker run -d -p 8080:8080 --name llamacommunicator llamacommunicator
```

Now you can either access the UI via localhost:8080 or -your.local.ip.here-:8080 and can share that with people you trust on your network!
