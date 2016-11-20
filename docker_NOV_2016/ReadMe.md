
#### Docker Basics (using Tomcat as an example)

* get the image: 
* `docker pull tomcat`

* run a container using port mapping and the current directory as a volume:
* (Note: one needs `DOCKER_HOST` later)
* `echo $DOCKER_HOST`
* `docker run -d -p 5155:8080 -v $PWD:/data -t tomcat`

* browse to http//DOCKER_HOST:5155 , where `DOCKER_HOST` is appropriate value 

* to enter container via bash:
* `docker ps` (to see containerId or name)
* `docker exec -it <containerIdOrName> bash`
* `cd /data` to view files from host machine
