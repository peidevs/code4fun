
#### Using Mono with Docker

##### Setup Docker and Mono Image

* These instructions work for Mac OS X. Tweak as appropriate
* Install Docker from [here](https://www.docker.com/) 
* Open 'Docker Quick Start Terminal'
* Search online repository: `docker search mono`
* Pull the Mono image: `docker pull mono` 

##### Test Mono Container

* For newbies, a *container* is essentially a *virtual machine* (a gross simplication, but ...)
* Set env variable `MY_SRC_HOME` to be your desired working directory (it will be `/data` in the container)
    * ensure that it contains code from this GitHub repo
* Start a Mono container: `docker run -i -t -v $MY_SRC_HOME:/data  mono:latest`
* At the container prompt, try the `Hello` program:
```bash
cd /data
mcs Hello.cs
mono Hello.exe
```
* Profit!
