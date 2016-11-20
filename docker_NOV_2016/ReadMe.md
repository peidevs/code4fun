
#### Docker Basics (using Jenkins as an example)

* get the image: 
* `docker pull jenkins`

* run a container using port mapping and the current directory as a volume:
* (Note: one needs `DOCKER_HOST` later)
* `echo $DOCKER_HOST`
* `docker run -d -p 5155:8080 -v $PWD:/var/jenkins_home -t jenkins`

* browse to http//DOCKER_HOST:5155 , where `DOCKER_HOST` is appropriate value 

* to enter container via bash:
* `docker exec -it <containerIdOrName> bash`
