import * as express from 'express';
import * as graphqlHTTP from 'express-graphql';

import db from './models';
import schema from './graphql/schema';
import { extractJwtMiddlware } from './middlewares/extract-jwt.middleware';

class App {
    public express: express.Application;

    /**
     *
     */
    constructor() {
        this.express = express();
        this.middleware();
    }

    private middleware(): void {
        this.express.use('/graphql',

            extractJwtMiddlware(),

            (req, res, next) => {
                req['context'].db = db;
                next();
            },

            graphqlHTTP((req) => ({
                schema: schema,
                graphiql: true,
                context: req['context']
            }))
        );
    }
}

export default new App().express;