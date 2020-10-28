FROM node:10.15-alpine AS store-admin
EXPOSE 4700 49152
USER node

RUN mkdir /home/node/.npm-global
ENV PATH=/home/node/.npm-global/bin:$PATH
ENV NPM_CONFIG_PREFIX=/home/node/.npm-global

RUN npm install -g @angular/cli@

WORKDIR /app
CMD ["ng", "serve", "--port", "4700", "--host", "0.0.0.0", "--disable-host-check", "--poll", "2000"]
