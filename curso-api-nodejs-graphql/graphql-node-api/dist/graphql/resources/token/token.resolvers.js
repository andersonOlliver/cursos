"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const jwt = require("jsonwebtoken");
exports.tokenResolvers = {
    Mutation: {
        createToken: (parent, { email, password }, { db }) => {
            return db.User.findOne({
                where: { email: email },
                attributes: ['id', 'password']
            }).then((user) => {
                let errorMessage = 'Unauthorized, wrong email or password!';
                if (!user || !user.isPassword(user.get('password'), password)) {
                    throw new Error(errorMessage);
                }
                const payload = { sub: user.get('id') };
                return {
                    token: jwt.sign(payload, 'iron_man')
                };
            });
        }
    }
};
