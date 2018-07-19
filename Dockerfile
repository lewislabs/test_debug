FROM microsoft/dotnet:1.1.2-sdk
RUN apt-get -m update
RUN apt-get install -y wget unzip
WORKDIR /vsdbg

RUN curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg
WORKDIR /app
ENTRYPOINT ["/bin/bash", "-c", "sleep infinity"]
COPY . /app