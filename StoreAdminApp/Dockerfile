FROM node:10.15-alpine AS store-admin
EXPOSE 4500 49151
USER node

RUN mkdir /home/node/.npm-global
ENV PATH=/home/node/.npm-global/bin:$PATH
ENV NPM_CONFIG_PREFIX=/home/node/.npm-global

RUN npm install -g @angular/cli@8.1.0

WORKDIR /app
CMD ["ng", "serve", "--port", "4500", "--host", "0.0.0.0", "--disable-host-check", "--poll", "2000"]
