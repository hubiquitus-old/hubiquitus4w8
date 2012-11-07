/*
 * Copyright (c) Novedia Group 2012.
 *
 *     This file is part of Hubiquitus.
 *
 *     Hubiquitus is free software: you can redistribute it and/or modify
 *     it under the terms of the GNU General Public License as published by
 *     the Free Software Foundation, either version 3 of the License, or
 *     (at your option) any later version.
 *
 *     Hubiquitus is distributed in the hope that it will be useful,
 *     but WITHOUT ANY WARRANTY; without even the implied warranty of
 *     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *     GNU General Public License for more details.
 *
 *     You should have received a copy of the GNU General Public License
 *     along with Hubiquitus.  If not, see <http://www.gnu.org/licenses/>.
 */



namespace hubiquitus4w8.hapi.test
{
    partial class testForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.connectBt = new System.Windows.Forms.Button();
            this.disconnectBt = new System.Windows.Forms.Button();
            this.subscribeBt = new System.Windows.Forms.Button();
            this.unsubscribeBt = new System.Windows.Forms.Button();
            this.publisherBt = new System.Windows.Forms.Button();
            this.getLastMsgsBt = new System.Windows.Forms.Button();
            this.getSubscriptionsBt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.endpointTextBox = new System.Windows.Forms.TextBox();
            this.actorTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nbLastMessagesTextBox = new System.Windows.Forms.TextBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.convidTextBox = new System.Windows.Forms.TextBox();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.getThreadBt = new System.Windows.Forms.Button();
            this.getThreadsBt = new System.Windows.Forms.Button();
            this.setFilterBt = new System.Windows.Forms.Button();
            this.getRelevantMsgBt = new System.Windows.Forms.Button();
            this.persistentRBt = new System.Windows.Forms.RadioButton();
            this.console = new System.Windows.Forms.TextBox();
            this.pubConvStateBt = new System.Windows.Forms.Button();
            this.notTransientRBt = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.timeoutTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.relevanceOffsetTextBox = new System.Windows.Forms.TextBox();
            this.createChannelBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(155, 9);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(447, 20);
            this.usernameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "password";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(155, 41);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(447, 20);
            this.passwordTextBox.TabIndex = 3;
            // 
            // connectBt
            // 
            this.connectBt.Location = new System.Drawing.Point(15, 506);
            this.connectBt.Name = "connectBt";
            this.connectBt.Size = new System.Drawing.Size(75, 23);
            this.connectBt.TabIndex = 4;
            this.connectBt.Text = "connect";
            this.connectBt.UseVisualStyleBackColor = true;
            this.connectBt.Click += new System.EventHandler(this.connectBt_Click);
            // 
            // disconnectBt
            // 
            this.disconnectBt.Location = new System.Drawing.Point(99, 506);
            this.disconnectBt.Name = "disconnectBt";
            this.disconnectBt.Size = new System.Drawing.Size(75, 23);
            this.disconnectBt.TabIndex = 5;
            this.disconnectBt.Text = "disconnect";
            this.disconnectBt.UseVisualStyleBackColor = true;
            this.disconnectBt.Click += new System.EventHandler(this.disconnectBt_Click);
            // 
            // subscribeBt
            // 
            this.subscribeBt.Location = new System.Drawing.Point(261, 506);
            this.subscribeBt.Name = "subscribeBt";
            this.subscribeBt.Size = new System.Drawing.Size(75, 23);
            this.subscribeBt.TabIndex = 6;
            this.subscribeBt.Text = "subscribe";
            this.subscribeBt.UseVisualStyleBackColor = true;
            this.subscribeBt.Click += new System.EventHandler(this.subscribeBt_Click);
            // 
            // unsubscribeBt
            // 
            this.unsubscribeBt.Location = new System.Drawing.Point(180, 535);
            this.unsubscribeBt.Name = "unsubscribeBt";
            this.unsubscribeBt.Size = new System.Drawing.Size(75, 23);
            this.unsubscribeBt.TabIndex = 7;
            this.unsubscribeBt.Text = "unsubscribe";
            this.unsubscribeBt.UseVisualStyleBackColor = true;
            this.unsubscribeBt.Click += new System.EventHandler(this.unsubscribeBt_Click);
            // 
            // publisherBt
            // 
            this.publisherBt.Location = new System.Drawing.Point(180, 505);
            this.publisherBt.Name = "publisherBt";
            this.publisherBt.Size = new System.Drawing.Size(75, 23);
            this.publisherBt.TabIndex = 8;
            this.publisherBt.Text = "send";
            this.publisherBt.UseVisualStyleBackColor = true;
            this.publisherBt.Click += new System.EventHandler(this.sendBt_Click);
            // 
            // getLastMsgsBt
            // 
            this.getLastMsgsBt.Location = new System.Drawing.Point(342, 506);
            this.getLastMsgsBt.Name = "getLastMsgsBt";
            this.getLastMsgsBt.Size = new System.Drawing.Size(75, 23);
            this.getLastMsgsBt.TabIndex = 9;
            this.getLastMsgsBt.Text = "getLastMsgs";
            this.getLastMsgsBt.UseVisualStyleBackColor = true;
            this.getLastMsgsBt.Click += new System.EventHandler(this.getLastMsgsBt_Click);
            // 
            // getSubscriptionsBt
            // 
            this.getSubscriptionsBt.Location = new System.Drawing.Point(433, 506);
            this.getSubscriptionsBt.Name = "getSubscriptionsBt";
            this.getSubscriptionsBt.Size = new System.Drawing.Size(98, 23);
            this.getSubscriptionsBt.TabIndex = 10;
            this.getSubscriptionsBt.Text = "getSubscriptions";
            this.getSubscriptionsBt.UseVisualStyleBackColor = true;
            this.getSubscriptionsBt.Click += new System.EventHandler(this.getSubscriptionsBt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "endpoint";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Actor (channel)";
            // 
            // endpointTextBox
            // 
            this.endpointTextBox.Location = new System.Drawing.Point(155, 72);
            this.endpointTextBox.Name = "endpointTextBox";
            this.endpointTextBox.Size = new System.Drawing.Size(447, 20);
            this.endpointTextBox.TabIndex = 15;
            // 
            // actorTextBox
            // 
            this.actorTextBox.Location = new System.Drawing.Point(155, 97);
            this.actorTextBox.Name = "actorTextBox";
            this.actorTextBox.Size = new System.Drawing.Size(447, 20);
            this.actorTextBox.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "nbLastMessages";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "message";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "convid";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "status";
            // 
            // nbLastMessagesTextBox
            // 
            this.nbLastMessagesTextBox.Location = new System.Drawing.Point(154, 130);
            this.nbLastMessagesTextBox.Name = "nbLastMessagesTextBox";
            this.nbLastMessagesTextBox.Size = new System.Drawing.Size(447, 20);
            this.nbLastMessagesTextBox.TabIndex = 26;
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(154, 172);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(447, 20);
            this.messageTextBox.TabIndex = 27;
            // 
            // convidTextBox
            // 
            this.convidTextBox.Location = new System.Drawing.Point(154, 208);
            this.convidTextBox.Name = "convidTextBox";
            this.convidTextBox.Size = new System.Drawing.Size(447, 20);
            this.convidTextBox.TabIndex = 28;
            // 
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(154, 240);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(447, 20);
            this.statusTextBox.TabIndex = 29;
            // 
            // getThreadBt
            // 
            this.getThreadBt.Location = new System.Drawing.Point(13, 536);
            this.getThreadBt.Name = "getThreadBt";
            this.getThreadBt.Size = new System.Drawing.Size(75, 23);
            this.getThreadBt.TabIndex = 33;
            this.getThreadBt.Text = "getThread";
            this.getThreadBt.UseVisualStyleBackColor = true;
            this.getThreadBt.Click += new System.EventHandler(this.getThreadBt_Click);
            // 
            // getThreadsBt
            // 
            this.getThreadsBt.Location = new System.Drawing.Point(99, 535);
            this.getThreadsBt.Name = "getThreadsBt";
            this.getThreadsBt.Size = new System.Drawing.Size(75, 23);
            this.getThreadsBt.TabIndex = 34;
            this.getThreadsBt.Text = "getTreads";
            this.getThreadsBt.UseVisualStyleBackColor = true;
            this.getThreadsBt.Click += new System.EventHandler(this.getThreadsBt_Click);
            // 
            // setFilterBt
            // 
            this.setFilterBt.Location = new System.Drawing.Point(261, 534);
            this.setFilterBt.Name = "setFilterBt";
            this.setFilterBt.Size = new System.Drawing.Size(75, 23);
            this.setFilterBt.TabIndex = 35;
            this.setFilterBt.Text = "setFilter";
            this.setFilterBt.UseVisualStyleBackColor = true;
            this.setFilterBt.Click += new System.EventHandler(this.setFilterBt_Click);
            // 
            // getRelevantMsgBt
            // 
            this.getRelevantMsgBt.Location = new System.Drawing.Point(342, 535);
            this.getRelevantMsgBt.Name = "getRelevantMsgBt";
            this.getRelevantMsgBt.Size = new System.Drawing.Size(97, 23);
            this.getRelevantMsgBt.TabIndex = 38;
            this.getRelevantMsgBt.Text = "getRelevantMsg";
            this.getRelevantMsgBt.UseVisualStyleBackColor = true;
            this.getRelevantMsgBt.Click += new System.EventHandler(this.getRelevantMsgBt_Click);
            // 
            // persistentRBt
            // 
            this.persistentRBt.AutoSize = true;
            this.persistentRBt.Checked = true;
            this.persistentRBt.Location = new System.Drawing.Point(15, 331);
            this.persistentRBt.Name = "persistentRBt";
            this.persistentRBt.Size = new System.Drawing.Size(70, 17);
            this.persistentRBt.TabIndex = 42;
            this.persistentRBt.TabStop = true;
            this.persistentRBt.Text = "persistent";
            this.persistentRBt.UseVisualStyleBackColor = true;
            // 
            // console
            // 
            this.console.Location = new System.Drawing.Point(638, 9);
            this.console.Multiline = true;
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.console.Size = new System.Drawing.Size(290, 479);
            this.console.TabIndex = 43;
            // 
            // pubConvStateBt
            // 
            this.pubConvStateBt.Location = new System.Drawing.Point(537, 506);
            this.pubConvStateBt.Name = "pubConvStateBt";
            this.pubConvStateBt.Size = new System.Drawing.Size(92, 23);
            this.pubConvStateBt.TabIndex = 44;
            this.pubConvStateBt.Text = "pubConvState";
            this.pubConvStateBt.UseVisualStyleBackColor = true;
            this.pubConvStateBt.Click += new System.EventHandler(this.pubConvStateBt_Click);
            // 
            // notTransientRBt
            // 
            this.notTransientRBt.AutoSize = true;
            this.notTransientRBt.Location = new System.Drawing.Point(15, 363);
            this.notTransientRBt.Name = "notTransientRBt";
            this.notTransientRBt.Size = new System.Drawing.Size(88, 17);
            this.notTransientRBt.TabIndex = 45;
            this.notTransientRBt.TabStop = true;
            this.notTransientRBt.Text = "not persistent";
            this.notTransientRBt.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "timeout";
            // 
            // timeoutTextBox
            // 
            this.timeoutTextBox.Location = new System.Drawing.Point(154, 269);
            this.timeoutTextBox.Name = "timeoutTextBox";
            this.timeoutTextBox.Size = new System.Drawing.Size(447, 20);
            this.timeoutTextBox.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "relevanceOffset";
            // 
            // relevanceOffsetTextBox
            // 
            this.relevanceOffsetTextBox.Location = new System.Drawing.Point(155, 301);
            this.relevanceOffsetTextBox.Name = "relevanceOffsetTextBox";
            this.relevanceOffsetTextBox.Size = new System.Drawing.Size(447, 20);
            this.relevanceOffsetTextBox.TabIndex = 49;
            // 
            // createChannelBt
            // 
            this.createChannelBt.Location = new System.Drawing.Point(456, 536);
            this.createChannelBt.Name = "createChannelBt";
            this.createChannelBt.Size = new System.Drawing.Size(75, 23);
            this.createChannelBt.TabIndex = 51;
            this.createChannelBt.Text = "CreateChannel";
            this.createChannelBt.UseVisualStyleBackColor = true;
            this.createChannelBt.Click += new System.EventHandler(this.createChannelBt_Click);
            // 
            // testForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 577);
            this.Controls.Add(this.createChannelBt);
            this.Controls.Add(this.relevanceOffsetTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.timeoutTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.notTransientRBt);
            this.Controls.Add(this.pubConvStateBt);
            this.Controls.Add(this.console);
            this.Controls.Add(this.persistentRBt);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.getRelevantMsgBt);
            this.Controls.Add(this.setFilterBt);
            this.Controls.Add(this.getThreadsBt);
            this.Controls.Add(this.getThreadBt);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.convidTextBox);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.nbLastMessagesTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.actorTextBox);
            this.Controls.Add(this.endpointTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.getSubscriptionsBt);
            this.Controls.Add(this.getLastMsgsBt);
            this.Controls.Add(this.publisherBt);
            this.Controls.Add(this.unsubscribeBt);
            this.Controls.Add(this.subscribeBt);
            this.Controls.Add(this.disconnectBt);
            this.Controls.Add(this.connectBt);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "testForm";
            this.Text = "testForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;

        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox endpointTextBox;
        private System.Windows.Forms.TextBox actorTextBox;
        private System.Windows.Forms.TextBox nbLastMessagesTextBox;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.TextBox convidTextBox;
        private System.Windows.Forms.TextBox statusTextBox;

        private System.Windows.Forms.Button connectBt;
        private System.Windows.Forms.Button disconnectBt;
        private System.Windows.Forms.Button subscribeBt;
        private System.Windows.Forms.Button unsubscribeBt;
        private System.Windows.Forms.Button publisherBt;
        private System.Windows.Forms.Button getLastMsgsBt;
        private System.Windows.Forms.Button getSubscriptionsBt;
        private System.Windows.Forms.Button getThreadBt;
        private System.Windows.Forms.Button getThreadsBt;
        private System.Windows.Forms.Button setFilterBt;
        private System.Windows.Forms.Button getRelevantMsgBt;
        private System.Windows.Forms.RadioButton persistentRBt;
        private System.Windows.Forms.TextBox console;
        private System.Windows.Forms.Button pubConvStateBt;
        private System.Windows.Forms.RadioButton notTransientRBt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox timeoutTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox relevanceOffsetTextBox;
        private System.Windows.Forms.Button createChannelBt;

    }
}