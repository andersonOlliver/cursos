"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const express = require("express");
const graphqlHTTP = require("express-graphql");
const models_1 = require("./models");
const schema_1 = require("./graphql/schema");
const extract_jwt_middleware_1 = require("./middlewares/extract-jwt.middleware");
class App {
    /**
     *
     */
    constructor() {
        this.express = express();
        this.middleware();
    }
    middleware() {
        this.express.use('/graphql', extract_jwt_middleware_1.extractJwtMiddlware(), (req, res, next) => {
            req['context'].db = models_1.default;
            next();
        }, graphqlHTTP((req) => ({
            schema: schema_1.default,
            graphiql: true,
            context: req['context']
        })));
    }
}
exports.default = new App().express;
