"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const jwt = require("jsonwebtoken");
const models_1 = require("../models");
exports.extractJwtMiddlware = () => {
    return (req, res, next) => {
        let authorization = req.get('authorization');
        let token = authorization ? authorization.split(' ')[1] : undefined;
        req['context'] = {};
        req['context']['authorization'] = authorization;
        if (!token) {
            return next();
        }
        jwt.verify(token, 'iron_man', (err, decoded) => {
            if (err) {
                return next();
            }
            models_1.default.User.findById(decoded.sub, {
                attributes: ['id', 'email']
            }).then((user) => {
                if (user) {
                    req['context']['user'] = {
                        id: user.get('id'),
                        email: user.get('email')
                    };
                }
                return next();
            });
        });
    };
};
