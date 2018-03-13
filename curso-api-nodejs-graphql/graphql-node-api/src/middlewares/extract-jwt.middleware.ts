import { RequestHandler, Request, Response } from "express";
import { NextFunction } from "express-serve-static-core";
import * as jwt from 'jsonwebtoken';
import db from '../models'
import { UserInstance } from "../models/UserModel";

export const extractJwtMiddlware = (): RequestHandler => {
    return (req: Request, res: Response, next: NextFunction): void => {
        let authorization: string = req.get('authorization');
        let token: string = authorization ? authorization.split(' ')[1] : undefined;

        req['context'] = {};
        req['context']['authorization'] = authorization;

        if (!token) { return next(); }

        jwt.verify(token, 'iron_man', (err, decoded: any) => {
            if (err) { return next(); }

            db.User.findById(decoded.sub, {
                attributes: ['id', 'email']
            }).then((user: UserInstance) => {
                if (user) {
                    req['context']['user'] = {
                       id: user.get('id'),
                       email: user.get('email')
                    };
                }

                return next();
            })
        });
    }
};